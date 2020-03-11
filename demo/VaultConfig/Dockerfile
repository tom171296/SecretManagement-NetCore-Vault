FROM vault:1.3.3
WORKDIR /vault/config

COPY ./Config.hcl .

ENTRYPOINT ["vault", "server", "-config", "/vault/config/Config.hcl"]