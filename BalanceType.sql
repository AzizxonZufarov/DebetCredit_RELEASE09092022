PGDMP     +            	        z            DebetCredit    14.5    14.5     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16485    DebetCredit    DATABASE     j   CREATE DATABASE "DebetCredit" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "DebetCredit";
                postgres    false            �            1259    16578    BalanceType    TABLE     _   CREATE TABLE public."BalanceType" (
    "ID" integer NOT NULL,
    "Name" character varying
);
 !   DROP TABLE public."BalanceType";
       public         heap    postgres    false            �          0    16578    BalanceType 
   TABLE DATA           5   COPY public."BalanceType" ("ID", "Name") FROM stdin;
    public          postgres    false    215   S       g           2606    16584    BalanceType BalanceType_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."BalanceType"
    ADD CONSTRAINT "BalanceType_pkey" PRIMARY KEY ("ID");
 J   ALTER TABLE ONLY public."BalanceType" DROP CONSTRAINT "BalanceType_pkey";
       public            postgres    false    215            �   '   x�3�0�bÅ[/컰�ˈ�.6B�1z\\\ kD�     