PGDMP     '            	        z            DebetCredit    14.5    14.5     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16485    DebetCredit    DATABASE     j   CREATE DATABASE "DebetCredit" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "DebetCredit";
                postgres    false            �            1259    16550    User    TABLE     �   CREATE TABLE public."User" (
    "ID" integer NOT NULL,
    "Username" character varying(100) NOT NULL,
    "Hash" character varying(64) NOT NULL
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    16549    User_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."User_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public."User_ID_seq";
       public          postgres    false    210            �           0    0    User_ID_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."User_ID_seq" OWNED BY public."User"."ID";
          public          postgres    false    209            f           2604    16553    User ID    DEFAULT     h   ALTER TABLE ONLY public."User" ALTER COLUMN "ID" SET DEFAULT nextval('public."User_ID_seq"'::regclass);
 :   ALTER TABLE public."User" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    209    210    210            �          0    16550    User 
   TABLE DATA           :   COPY public."User" ("ID", "Username", "Hash") FROM stdin;
    public          postgres    false    210   `
       �           0    0    User_ID_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public."User_ID_seq"', 1, true);
          public          postgres    false    209            h           2606    16555    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("ID");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    210            �   M   x����@��(��~<�*L�11��Cwk��������u�X�;�*�ȶ �ɘp���bݤMf΀�ЬtnD���     