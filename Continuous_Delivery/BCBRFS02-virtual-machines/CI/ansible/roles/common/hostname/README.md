hostname
===

A role for setting hostname based on the inventory name.

Usage
---

#### Simple usage

```yaml

roles:
  - common/docker
  - common/hostname

```

#### Hostname validation usage

```yaml
roles:
  - { role: common/hostname, validation_regex: '([a-z0-9]+)-([a-z0-9]+)-(prod|dev)-[0-9]' }
```

#### add `local-responder` host bound to server's external ip

```yaml
    - { role: common/hostname, enable_local_responder: true }
```
