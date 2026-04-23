####################################################################
# Connells Infrastructure — Main Terraform Configuration
# 
# STATUS: Incomplete — use GitHub Copilot to finish this!
#
# This configuration should deploy:
# - A resource group
# - A virtual network with web and data subnets
# - Network security groups for each subnet
# - A storage account with a blob container
# - A key vault for secrets
#
# Several resources are missing or have TODOs.
####################################################################

terraform {
  required_version = ">= 1.5.0"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.80"
    }
  }
}

provider "azurerm" {
  features {
    key_vault {
      purge_soft_delete_on_destroy = true
    }
  }
}

# ──────────────────────────────────────────────
# Resource Group
# ──────────────────────────────────────────────
resource "azurerm_resource_group" "main" {
  name     = "${var.project_name}-${var.environment}-rg"
  location = var.location

  tags = {
    environment = var.environment
    project     = var.project_name
    managed_by  = "terraform"
  }
}

# ──────────────────────────────────────────────
# Virtual Network
# ──────────────────────────────────────────────
resource "azurerm_virtual_network" "main" {
  name                = "${var.project_name}-${var.environment}-vnet"
  resource_group_name = azurerm_resource_group.main.name
  location            = azurerm_resource_group.main.location
  address_space       = [var.vnet_address_space]

  tags = azurerm_resource_group.main.tags
}

# ──────────────────────────────────────────────
# Subnets
# ──────────────────────────────────────────────
resource "azurerm_subnet" "web" {
  name                 = "web-subnet"
  resource_group_name  = azurerm_resource_group.main.name
  virtual_network_name = azurerm_virtual_network.main.name
  address_prefixes     = [var.web_subnet_prefix]
}

# TODO: Create a "data-subnet" for databases and internal services
# It should use var.data_subnet_prefix


# ──────────────────────────────────────────────
# Network Security Groups
# ──────────────────────────────────────────────

# NSG for the web subnet — allows HTTPS and HTTP inbound
resource "azurerm_network_security_group" "web" {
  name                = "${var.project_name}-${var.environment}-web-nsg"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  security_rule {
    name                       = "AllowHTTPS"
    priority                   = 100
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  # TODO: Add a rule to allow HTTP (port 80) at priority 110

  # TODO: Add a rule to deny all other inbound traffic at priority 200

  tags = azurerm_resource_group.main.tags
}

# TODO: Create an NSG for the data subnet that:
# - Allows traffic from the web subnet only (ports 1433 for SQL, 6379 for Redis)
# - Denies all other inbound traffic
# - Associate it with the data subnet


# ──────────────────────────────────────────────
# Storage Account
# ──────────────────────────────────────────────

# TODO: Create a storage account with:
# - Standard LRS replication
# - A blob container called "backups" with private access
# - A blob container called "documents" with private access
# - Minimum TLS version 1.2
# - HTTPS traffic only
# - Tags matching the resource group


# ──────────────────────────────────────────────
# Key Vault
# ──────────────────────────────────────────────

# TODO: Create a Key Vault with:
# - Standard SKU
# - Soft delete enabled with 7-day retention
# - Purge protection enabled
# - An access policy for the current tenant
# - Tags matching the resource group
