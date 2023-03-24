--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-03-24 19:53:22

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 214 (class 1259 OID 16606)
-- Name: brand_car; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.brand_car (
    id integer NOT NULL,
    name text NOT NULL,
    active boolean DEFAULT true
);


ALTER TABLE public.brand_car OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16614)
-- Name: model_car; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.model_car (
    id integer NOT NULL,
    brand_id integer,
    name text NOT NULL,
    active boolean DEFAULT true
);


ALTER TABLE public.model_car OWNER TO postgres;

--
-- TOC entry 3325 (class 0 OID 16606)
-- Dependencies: 214
-- Data for Name: brand_car; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.brand_car (id, name, active) VALUES (1, 'Audi', true);
INSERT INTO public.brand_car (id, name, active) VALUES (2, 'BMW', false);
INSERT INTO public.brand_car (id, name, active) VALUES (3, 'Nissan', true);
INSERT INTO public.brand_car (id, name, active) VALUES (4, 'Toyota', true);
INSERT INTO public.brand_car (id, name, active) VALUES (5, 'Lada', true);


--
-- TOC entry 3326 (class 0 OID 16614)
-- Dependencies: 215
-- Data for Name: model_car; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.model_car (id, brand_id, name, active) VALUES (1, 1, 'A4', true);
INSERT INTO public.model_car (id, brand_id, name, active) VALUES (2, 1, 'R8', false);
INSERT INTO public.model_car (id, brand_id, name, active) VALUES (4, 3, 'GTR', true);
INSERT INTO public.model_car (id, brand_id, name, active) VALUES (5, 4, 'Supra', false);
INSERT INTO public.model_car (id, brand_id, name, active) VALUES (3, 2, 'M3 GTR', false);
INSERT INTO public.model_car (id, brand_id, name, active) VALUES (6, 5, 'Priora', true);
INSERT INTO public.model_car (id, brand_id, name, active) VALUES (7, 5, 'Kalina', true);


--
-- TOC entry 3179 (class 2606 OID 16613)
-- Name: brand_car brand_car_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.brand_car
    ADD CONSTRAINT brand_car_pkey PRIMARY KEY (id);


--
-- TOC entry 3181 (class 2606 OID 16621)
-- Name: model_car model_car_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.model_car
    ADD CONSTRAINT model_car_pkey PRIMARY KEY (id);


--
-- TOC entry 3182 (class 2606 OID 16622)
-- Name: model_car model_car_brand_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.model_car
    ADD CONSTRAINT model_car_brand_id_fkey FOREIGN KEY (brand_id) REFERENCES public.brand_car(id);


-- Completed on 2023-03-24 19:53:22

--
-- PostgreSQL database dump complete
--

