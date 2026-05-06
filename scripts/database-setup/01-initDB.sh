set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL

CREATE TABLE Searches (
    ID                  SERIAL PRIMARY KEY,
    SearchedAt         TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    URL                 VARCHAR(255) NOT NULL,
    SearchQuery        VARCHAR(255) NOT NULL,
    NumberOfOccurrences INT NOT NULL DEFAULT 0
);

EOSQL

