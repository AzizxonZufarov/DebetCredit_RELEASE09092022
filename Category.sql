PGDMP                 	        z            DebetCredit    14.5    14.5     ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16485    DebetCredit    DATABASE     j   CREATE DATABASE "DebetCredit" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "DebetCredit";
                postgres    false            ?            1259    16564    Category    TABLE     ?   CREATE TABLE public."Category" (
    "ID" integer NOT NULL,
    "Name" character varying(200) NOT NULL,
    "TypeID" integer
);
    DROP TABLE public."Category";
       public         heap    postgres    false            ?            1259    16563    Category_ID_seq    SEQUENCE     ?   CREATE SEQUENCE public."Category_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Category_ID_seq";
       public          postgres    false    214            ?           0    0    Category_ID_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Category_ID_seq" OWNED BY public."Category"."ID";
          public          postgres    false    213            f           2604    16567    Category ID    DEFAULT     p   ALTER TABLE ONLY public."Category" ALTER COLUMN "ID" SET DEFAULT nextval('public."Category_ID_seq"'::regclass);
 >   ALTER TABLE public."Category" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    213    214    214            ?          0    16564    Category 
   TABLE DATA           <   COPY public."Category" ("ID", "Name", "TypeID") FROM stdin;
    public          postgres    false    214   ?
       ?           0    0    Category_ID_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Category_ID_seq"', 23, true);
          public          postgres    false    213            h           2606    16569    Category Category_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Category"
    ADD CONSTRAINT "Category_pkey" PRIMARY KEY ("ID");
 D   ALTER TABLE ONLY public."Category" DROP CONSTRAINT "Category_pkey";
       public            postgres    false    214            ?   3  x?mQKn?0]ۧ?	?@?$?DO??GUDbS?]?J? ??? Wxs?>?,Z??3~?>C???Q^0?1??^J??Ԇ??~/kx\?\9??}O?d?3?
oq?DE??l)???????G?w,q??R???9???͚䄯>XT???p#??Z
?r??Z?H?0?C'V? ???^
b?N,[??)?????d??-??(?EK	?C??fy?????2?s+?B?GC?A????V?W?6?l??????,?q???ߍ???_?\????в??O?1???n??6?zs????,=O     