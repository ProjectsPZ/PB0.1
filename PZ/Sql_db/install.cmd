@echo off
TITLE Setup SQL

SET PGBIN="C:\Program Files (x86)\PostgreSQL\9.3\bin\psql.exe"
SET PGDATABASE=
SET PGHOST=localhost
SET PGPORT=5432
SET PGUSER=postgres
SET PGPASSWORD=123456

%PGBIN% -f public.sql

pause