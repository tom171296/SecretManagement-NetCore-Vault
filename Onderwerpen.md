https://www.vaultproject.io/
# Problems that it solves

Vaults allows clients that are authenticated against a different set of identity providers.
audit to different types of log management
store data in 'almost' any durable system

## Secret sprawl
- credential spread
    - source
    - config
    - version control

Vault => solve secret sprawl
-   Centralize them
-   Encrypt everything at rest/in transit
-   Acces control
-   audit trail

## Dynamic secrets - ephemeral secrets
Application are terrible in keeping secrets
- logs
- diagnostics
- monitoring

solved by dynamic secrets
- ephemeral - valid a bounded period of time
- unique to each client
- revocation mechanisme

applications store data used for data protection at rest
- encryption keys, easy to get wrong

## Key life cycle management / cryptographic offload
Vault expects that the application implements encryption wrong!
- provides "Encryption as a service"
    - named keys
    - High level api's to do encryption
        - encrypt
        - sign
        - verify
- Shields the encryption implementation and the key that is used 
- off load key management
    - Not many application do this correctly, so vault provides a way to do it


# Architecture
Highly plugable
## Core
Has many responsibilities like:
- Life cycle management
- proces requests correctly

## Auth identity
Let services authenticate via different ways
- provides a pluggable way of authenticating 
- Goal is to provide application/human identity

## Audit
Connect and stream out request auditing to an external system
- supports multiple audit logs

## Storage backends
store it's own data at rest
- Responsible for storing data at rest
    - RDBMS - MySQL, postgress
    - Consul
    - Cloud managed database - Google spanner
- Goal is to provide durable storage that is highly available - tolerate loss of one of these backends

## Secrets
Secret backends themself
- K/V pairs => username / password
- Enable dynamic secret capability
    - database => MySQL credentials 
    - RabbitMQ => dynamic credential message queue
    - AWS
    - PKI => certificate management

# Cluster
- Leader election
- Synchronize data to leader
- Restfull JSON API over HTTP

## Things to look into:
### DEV vs Server mode
- dev
build in, pre-configured server
    - userful for local development, testing and exploration
    - Not very secure
    - Everything is stored in memory
    - unsealed automatically
    - optionally set initial root token
**Don't RUN vault in dev mode on production**


# Deploying

## Initialize
### Key spreading
https://www.vaultproject.io/docs/concepts/pgp-gpg-keybase/

## Sealing

## FIRST secret
### Enabeling KV secret engine
### KV pair

## Dynamische secrets

## Built-in help

## Authentication
https://learn.hashicorp.com/vault/identity-access-management/iam-intro
- Much like a website
- create tokens/ revoke tokens

### Auth methods

### Policies

















    