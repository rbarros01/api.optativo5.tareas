PGDMP         5                |         	   optativov    15.2    15.2     
           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    32900 	   optativov    DATABASE     �   CREATE DATABASE optativov WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Philippines.1252';
    DROP DATABASE optativov;
                postgres    false            �            1259    32905    cliente    TABLE     L  CREATE TABLE public.cliente (
    id integer NOT NULL,
    id_banco integer,
    nombre character varying(255),
    apellido character varying(255),
    documento character varying(255),
    direccion character varying(255),
    email character varying(255),
    celular character varying(255),
    estado character varying(255)
);
    DROP TABLE public.cliente;
       public         heap    postgres    false            �            1259    32904    cliente_id_seq    SEQUENCE     �   CREATE SEQUENCE public.cliente_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.cliente_id_seq;
       public          postgres    false    216                       0    0    cliente_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.cliente_id_seq OWNED BY public.cliente.id;
          public          postgres    false    215            �            1259    32931    factura    TABLE     f  CREATE TABLE public.factura (
    id integer NOT NULL,
    id_cliente integer,
    nro_factura character varying(255),
    fecha_hora timestamp without time zone,
    total numeric(15,2),
    total_iva5 numeric(15,2),
    total_iva10 numeric(15,2),
    total_iva numeric(15,2),
    total_letras character varying(255),
    sucursal character varying(255)
);
    DROP TABLE public.factura;
       public         heap    postgres    false            �            1259    32930    factura_id_seq    SEQUENCE     �   CREATE SEQUENCE public.factura_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.factura_id_seq;
       public          postgres    false    218                       0    0    factura_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.factura_id_seq OWNED BY public.factura.id;
          public          postgres    false    217            �            1259    32901    persona    TABLE     �   CREATE TABLE public.persona (
    nombre character varying(55),
    apellido character varying(55),
    cedula character varying(11),
    cliekey character varying(100)
);
    DROP TABLE public.persona;
       public         heap    postgres    false            n           2604    32908 
   cliente id    DEFAULT     h   ALTER TABLE ONLY public.cliente ALTER COLUMN id SET DEFAULT nextval('public.cliente_id_seq'::regclass);
 9   ALTER TABLE public.cliente ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    215    216    216            o           2604    32934 
   factura id    DEFAULT     h   ALTER TABLE ONLY public.factura ALTER COLUMN id SET DEFAULT nextval('public.factura_id_seq'::regclass);
 9   ALTER TABLE public.factura ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    218    217    218                      0    32905    cliente 
   TABLE DATA           o   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, email, celular, estado) FROM stdin;
    public          postgres    false    216   �                 0    32931    factura 
   TABLE DATA           �   COPY public.factura (id, id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) FROM stdin;
    public          postgres    false    218   �                 0    32901    persona 
   TABLE DATA           D   COPY public.persona (nombre, apellido, cedula, cliekey) FROM stdin;
    public          postgres    false    214   �                  0    0    cliente_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.cliente_id_seq', 3, true);
          public          postgres    false    215                       0    0    factura_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.factura_id_seq', 4, true);
          public          postgres    false    217            q           2606    32912    cliente cliente_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT cliente_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT cliente_pkey;
       public            postgres    false    216            s           2606    32938    factura factura_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.factura DROP CONSTRAINT factura_pkey;
       public            postgres    false    218            t           2606    32939    factura factura_id_cliente_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_id_cliente_fkey FOREIGN KEY (id_cliente) REFERENCES public.cliente(id) ON DELETE CASCADE;
 I   ALTER TABLE ONLY public.factura DROP CONSTRAINT factura_id_cliente_fkey;
       public          postgres    false    218    3185    216               <   x�3�4�����,.)��K�NY�Z��CE������RF�&���p�1z\\\ �l$L            x������ � �            x������ � �     