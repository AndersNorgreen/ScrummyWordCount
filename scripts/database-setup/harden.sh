#!/bin/bash

set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL

-- Create admin users
CREATE ROLE momo WITH LOGIN SUPERUSER PASSWORD '${MOMO_PWD}';
CREATE ROLE jamie WITH LOGIN SUPERUSER PASSWORD '${JAMIE_PWD}';
CREATE ROLE anders WITH LOGIN SUPERUSER PASSWORD '${ANDERS_PWD}';

-- Create service user
CREATE ROLE scrummy_service WITH LOGIN PASSWORD '${SERVICE_PWD}';

-- Grant necessary access to the service user
GRANT CONNECT ON DATABASE $POSTGRES_DB TO scrummy_service;
GRANT USAGE ON SCHEMA public TO scrummy_service;
GRANT SELECT, INSERT, UPDATE ON ALL TABLES IN SCHEMA public TO scrummy_service;

-- Grant access to ID
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO scrummy_service;
ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT USAGE, SELECT ON SEQUENCES TO scrummy_service;

-- Grant access to later tables
ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO scrummy_service;

-- Remove postgres account privileges
ALTER ROLE postgres NOLOGIN;
EOSQL
