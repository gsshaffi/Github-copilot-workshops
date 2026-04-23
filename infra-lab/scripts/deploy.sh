#!/bin/bash
##############################################
# Deployment script for a .NET application
# 
# EXERCISE: Use Copilot to convert this Bash
# script to PowerShell, maintaining the same
# functionality and adding error handling.
#
# In Copilot Chat, try:
# "Convert this Bash script to PowerShell.
#  Keep the same logic, add try/catch error
#  handling, and use PowerShell best practices."
##############################################

set -euo pipefail

APP_NAME="connells-web"
DEPLOY_DIR="/opt/apps/$APP_NAME"
BACKUP_DIR="/opt/backups/$APP_NAME"
ARTIFACT_PATH="$1"
MAX_BACKUPS=5

log() {
    echo "[$(date '+%Y-%m-%d %H:%M:%S')] $1"
}

# Check artifact exists
if [ ! -f "$ARTIFACT_PATH" ]; then
    log "ERROR: Artifact not found: $ARTIFACT_PATH"
    exit 1
fi

# Create backup of current deployment
log "Creating backup..."
TIMESTAMP=$(date '+%Y%m%d_%H%M%S')
BACKUP_PATH="$BACKUP_DIR/${APP_NAME}_${TIMESTAMP}.tar.gz"
mkdir -p "$BACKUP_DIR"

if [ -d "$DEPLOY_DIR" ]; then
    tar -czf "$BACKUP_PATH" -C "$DEPLOY_DIR" .
    log "Backup created: $BACKUP_PATH"
else
    log "No existing deployment to backup"
fi

# Rotate old backups — keep only MAX_BACKUPS
BACKUP_COUNT=$(ls -1 "$BACKUP_DIR"/*.tar.gz 2>/dev/null | wc -l)
if [ "$BACKUP_COUNT" -gt "$MAX_BACKUPS" ]; then
    REMOVE_COUNT=$((BACKUP_COUNT - MAX_BACKUPS))
    ls -1t "$BACKUP_DIR"/*.tar.gz | tail -n "$REMOVE_COUNT" | xargs rm -f
    log "Rotated $REMOVE_COUNT old backup(s)"
fi

# Stop the application
log "Stopping $APP_NAME..."
systemctl stop "$APP_NAME" 2>/dev/null || log "Service not running"

# Deploy new version
log "Deploying new version..."
mkdir -p "$DEPLOY_DIR"
rm -rf "${DEPLOY_DIR:?}/"*

if [[ "$ARTIFACT_PATH" == *.tar.gz ]]; then
    tar -xzf "$ARTIFACT_PATH" -C "$DEPLOY_DIR"
elif [[ "$ARTIFACT_PATH" == *.zip ]]; then
    unzip -q "$ARTIFACT_PATH" -d "$DEPLOY_DIR"
else
    cp "$ARTIFACT_PATH" "$DEPLOY_DIR/"
fi

# Set permissions
chown -R www-data:www-data "$DEPLOY_DIR"
chmod -R 755 "$DEPLOY_DIR"

# Start the application
log "Starting $APP_NAME..."
systemctl start "$APP_NAME"

# Health check
log "Running health check..."
sleep 5
HTTP_STATUS=$(curl -s -o /dev/null -w "%{http_code}" "http://localhost:5000/health" || echo "000")

if [ "$HTTP_STATUS" = "200" ]; then
    log "✅ Deployment successful — health check passed"
else
    log "❌ Health check failed (HTTP $HTTP_STATUS) — rolling back..."
    systemctl stop "$APP_NAME"
    rm -rf "${DEPLOY_DIR:?}/"*
    tar -xzf "$BACKUP_PATH" -C "$DEPLOY_DIR"
    systemctl start "$APP_NAME"
    log "Rollback complete"
    exit 1
fi
