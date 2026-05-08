set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL

CREATE TABLE Searches (
    Id                    SERIAL PRIMARY KEY,
    SearchedAt TIMESTAMP  WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL,
    URL                   VARCHAR(255) NOT NULL,
    SearchQuery           VARCHAR(255) NOT NULL,
    NumberOfOccurrences   INT NOT NULL DEFAULT 0
);

EOSQL
