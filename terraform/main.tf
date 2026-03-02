terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
  }
}

provider "azurerm" {
  features {}
}

# Create a new Resource Group
resource "azurerm_resource_group" "rg" {
  name     = "ReatsTracker-Staging-RG"
  location = "Switzerland North" 
}

# Create a free "Hosting Plan"
resource "azurerm_service_plan" "plan" {
  name                = "reatstracker-staging-plan" 
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  os_type             = "Linux"
  sku_name            = "F1"
}

# Create the Web App server itself for code
resource "azurerm_linux_web_app" "app" {
  name                = "reatstracker-api-staging" 
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_service_plan.plan.location
  service_plan_id     = azurerm_service_plan.plan.id

  
 site_config {
    always_on = false 
    application_stack {
      dotnet_version = "8.0"
    }
  }

# Immediately set the environment variables
app_settings = {
    "ConnectionStrings__DefaultConnection"       = var.db_connection_string
    "APPINSIGHTS_INSTRUMENTATIONKEY"             = azurerm_application_insights.appinsights.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING"      = azurerm_application_insights.appinsights.connection_string
    "ApplicationInsightsAgent_EXTENSION_VERSION" = "~3" 
  }
}

# Declare a variable for the database
variable "db_connection_string" {
  type        = string
  description = "Connection string for Neon PostgreSQL"
  sensitive   = true 
}

# Creating a Log Analytics Workspace
resource "azurerm_log_analytics_workspace" "law" {
  name                = "reatstracker-staging-law"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku                 = "PerGB2018"
  retention_in_days   = 30 # Keep logs for 30 days
}

# Create Application Insights 
resource "azurerm_application_insights" "appinsights" {
  name                = "reatstracker-staging-ai"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  workspace_id        = azurerm_log_analytics_workspace.law.id
  application_type    = "web"
}