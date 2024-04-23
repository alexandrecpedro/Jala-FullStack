# AZURE

## Concepts

### 1. Create a Resource Group

- Login in account
- Search resource group
- Instantiate a new resource group

### 2. Create Virtual Network

- Inside resource group
- New instance

### 3. Access Control Restrictions (Authorized People)

- Access Control (IAM)
- Add role assignment
  **It is valid to all resources inside resource group**

- Choose an option
- Choose _View_
- Choose _Assignment_
- Choose _Add assignment_
- Choose _Next_

**Process only allows one restriction to a single user each time**

- Choose _Members_ tab
- Choose _User, group, or service principal_
- Choose people
- Choose _Next_
- Choose _Next_
- Choose _Review + assign_

#### Overview

- Shows all resources created and respective privileges granted

### 4. Policy

**Create policy**

- Create Policy
- Choose _Definitions_
- Choose _+ Policy Definitions_
- Choose _..._
- Enter the desired data
- Choose _Next_

**Add policy to a resource group**

- Enter the desired resource group
- Choose _Policies_
- Choose _Assign policy_
- Choose _..._ and the policy above the options
- Choose _Add_
- Enter the desired data
- Choose _Review + create_
- Enter Parameters
