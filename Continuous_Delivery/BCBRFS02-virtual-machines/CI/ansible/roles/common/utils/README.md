utils
===

A role to install a common set of utilities that most be present in any system.

Configuration
---

The role has a curated list of packages that should be installed generically in all systems, the 
variable name is `DEFAULT_PACKAGES` and this list can be found at `vars/main.yml`.

There is another variable called `PACKAGES` which is actually read by the main task to install the packages, the 
default one is empty and can be found at `defaults/main.yml`.

In case this list of packages needs to be increased by adding new packages which could be specific for 
the distribution it can be extended by declaring a new list and this one can be concatenated with the `DEFAULT_PACKAGES` 
list.

Usage
---

#### Simple usage

```yaml
roles:
  - common/utils
  - common/hostname
```

#### Add additional packages specific for the system 

```yaml
vars:
  ADDITIONAL_PACKAGES:
    - java-11-amazon-corretto-headless
    - nmap-ncat
    - socat
    - python3-pip
    - dos2unix
  PACKAGES: "{{  DEFAULT_PACKAGES + ADDITIONAL_PACKAGES }}"

roles:
  - common/utils
```
