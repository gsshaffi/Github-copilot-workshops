###############################################
# Dockerfile for Connells .NET 8 Web API
#
# STATUS: Has several issues — use Copilot to 
# identify and fix them!
#
# Known problems:
# - Not using multi-stage build (image too large)
# - Running as root (security issue)
# - No .dockerignore considerations
# - Missing health check
# - Exposing wrong port
#
# In Copilot Chat, try:
# "Review this Dockerfile for best practices 
#  and security issues. Fix all problems."
###############################################

FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Copy everything
COPY . .

# Restore and build
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Expose port (the app actually runs on 8080)
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "/app/publish/Connells.Web.dll"]
