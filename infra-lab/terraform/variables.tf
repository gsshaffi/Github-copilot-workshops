####################################################################
# Variables for Connells Infrastructure
#
# STATUS: Some variables are defined, some are missing.
# Use Copilot to add the missing ones.
####################################################################

variable "project_name" {
  description = "The name of the project, used in resource naming"
  type        = string
  default     = "connells"
}

variable "environment" {
  description = "The deployment environment (dev, staging, prod)"
  type        = string
  default     = "dev"

  validation {
    condition     = contains(["dev", "staging", "prod"], var.environment)
    error_message = "Environment must be dev, staging, or prod."
  }
}

variable "location" {
  description = "Azure region for all resources"
  type        = string
  default     = "uksouth"
}

variable "vnet_address_space" {
  description = "Address space for the virtual network"
  type        = string
  default     = "10.0.0.0/16"
}

variable "web_subnet_prefix" {
  description = "Address prefix for the web subnet"
  type        = string
  default     = "10.0.1.0/24"
}

# TODO: Add variable for data_subnet_prefix (default: 10.0.2.0/24)

# TODO: Add variable for storage_account_tier (default: Standard)

# TODO: Add variable for storage_replication_type (default: LRS)

# TODO: Add a variable map for common_tags with sensible defaults
