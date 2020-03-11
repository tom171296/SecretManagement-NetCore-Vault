ui = true

storage "consul" {
  address = "consul:8500"
  path    = "vault/"
}

listener "tcp" {
 address     = "vault:8200"
 cluster_address  = "vault:8201"
 tls_disable = 1
}