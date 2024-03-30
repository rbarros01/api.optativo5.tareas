-- Database: optativov

-- DROP DATABASE IF EXISTS optativov;

CREATE DATABASE optativov
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Philippines.1252'
    LC_CTYPE = 'Spanish_Philippines.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
-- Table: public.persona

-- DROP TABLE IF EXISTS public.persona;

CREATE TABLE IF NOT EXISTS public.persona
(
    nombre character varying(55) COLLATE pg_catalog."default",
    apellido character varying(55) COLLATE pg_catalog."default",
    cedula character varying(11) COLLATE pg_catalog."default",
    cliekey character varying(100) COLLATE pg_catalog."default"
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.persona
    OWNER to postgres;
