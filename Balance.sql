PGDMP                 	        z            DebetCredit    14.5    14.5     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16485    DebetCredit    DATABASE     j   CREATE DATABASE "DebetCredit" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "DebetCredit";
                postgres    false            �            1259    16557    Balance    TABLE     �   CREATE TABLE public."Balance" (
    "ID" integer NOT NULL,
    "Date" date NOT NULL,
    "TypeID" integer NOT NULL,
    "CategoryID" integer NOT NULL,
    "Amount" integer NOT NULL,
    "Comment" character varying(200) NOT NULL
);
    DROP TABLE public."Balance";
       public         heap    postgres    false            �            1259    16556    Balance_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Balance_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Balance_ID_seq";
       public          postgres    false    212            �           0    0    Balance_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Balance_ID_seq" OWNED BY public."Balance"."ID";
          public          postgres    false    211            f           2604    16560 
   Balance ID    DEFAULT     n   ALTER TABLE ONLY public."Balance" ALTER COLUMN "ID" SET DEFAULT nextval('public."Balance_ID_seq"'::regclass);
 =   ALTER TABLE public."Balance" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    211    212    212            �          0    16557    Balance 
   TABLE DATA           ^   COPY public."Balance" ("ID", "Date", "TypeID", "CategoryID", "Amount", "Comment") FROM stdin;
    public          postgres    false    212          �           0    0    Balance_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Balance_ID_seq"', 21, true);
          public          postgres    false    211            h           2606    16562    Balance Balance_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Balance"
    ADD CONSTRAINT "Balance_pkey" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Balance" DROP CONSTRAINT "Balance_pkey";
       public            postgres    false    212            �   !  x�u�MN�0���)|� ��+w�0I	$6Hl��!��@�{���&����E�x���m�����ea�r�RMk��7��l�D�;�h����F��ޖ��y�[��JuR򪱢��;�4�̪@�+QE�t��pp��]�w��{Z(���M��U✅/,7�Ղ}`�O��h$�$]$'
��:V���9������^�kγ��&�-�G��~�ߵ*ۋAy���XM���p��0t��p�`������#�	E��L`h�	p+Z��dr\����7WZ�_Ԭ�     