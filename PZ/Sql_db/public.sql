/*
Navicat PGSQL Data Transfer

Source Server         : localhost_5432
Source Server Version : 90419
Source Host           : localhost:5432
Source Database       : postgres
Source Schema         : public

Target Server Type    : PGSQL
Target Server Version : 90419
File Encoding         : 65001

Date: 2018-10-14 22:20:30
*/


-- ----------------------------
-- Sequence structure for account_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."account_id_seq";
CREATE SEQUENCE "public"."account_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 2
 CACHE 1;
SELECT setval('"public"."account_id_seq"', 2, true);

-- ----------------------------
-- Sequence structure for accounts_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."accounts_id_seq";
CREATE SEQUENCE "public"."accounts_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."accounts_id_seq"', 1, true);

-- ----------------------------
-- Sequence structure for ban_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ban_seq";
CREATE SEQUENCE "public"."ban_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Sequence structure for channels_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."channels_id_seq";
CREATE SEQUENCE "public"."channels_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Sequence structure for check_event_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."check_event_seq";
CREATE SEQUENCE "public"."check_event_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."check_event_seq"', 1, true);

-- ----------------------------
-- Sequence structure for clan_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."clan_seq";
CREATE SEQUENCE "public"."clan_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."clan_seq"', 1, true);

-- ----------------------------
-- Sequence structure for clans_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."clans_id_seq";
CREATE SEQUENCE "public"."clans_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."clans_id_seq"', 1, true);

-- ----------------------------
-- Sequence structure for contas_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."contas_seq";
CREATE SEQUENCE "public"."contas_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."contas_seq"', 1, true);

-- ----------------------------
-- Sequence structure for gameservers_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."gameservers_id_seq";
CREATE SEQUENCE "public"."gameservers_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Sequence structure for gift_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."gift_id_seq";
CREATE SEQUENCE "public"."gift_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."gift_id_seq"', 1, true);

-- ----------------------------
-- Sequence structure for ipsystem_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ipsystem_id_seq";
CREATE SEQUENCE "public"."ipsystem_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Sequence structure for items_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."items_id_seq";
CREATE SEQUENCE "public"."items_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 9
 CACHE 1;
SELECT setval('"public"."items_id_seq"', 9, true);

-- ----------------------------
-- Sequence structure for jogador_amigo_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."jogador_amigo_seq";
CREATE SEQUENCE "public"."jogador_amigo_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."jogador_amigo_seq"', 1, true);

-- ----------------------------
-- Sequence structure for jogador_inventario_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."jogador_inventario_seq";
CREATE SEQUENCE "public"."jogador_inventario_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."jogador_inventario_seq"', 1, true);

-- ----------------------------
-- Sequence structure for jogador_mensagem_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."jogador_mensagem_seq";
CREATE SEQUENCE "public"."jogador_mensagem_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."jogador_mensagem_seq"', 1, true);

-- ----------------------------
-- Sequence structure for loja_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."loja_seq";
CREATE SEQUENCE "public"."loja_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."loja_seq"', 1, true);

-- ----------------------------
-- Sequence structure for message_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."message_id_seq";
CREATE SEQUENCE "public"."message_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."message_id_seq"', 1, true);

-- ----------------------------
-- Sequence structure for player_eqipment_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."player_eqipment_id_seq";
CREATE SEQUENCE "public"."player_eqipment_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."player_eqipment_id_seq"', 1, true);

-- ----------------------------
-- Sequence structure for player_friends_player_account_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."player_friends_player_account_id_seq";
CREATE SEQUENCE "public"."player_friends_player_account_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Sequence structure for players_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."players_id_seq";
CREATE SEQUENCE "public"."players_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."players_id_seq"', 1, true);

-- ----------------------------
-- Sequence structure for storage_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."storage_seq";
CREATE SEQUENCE "public"."storage_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."storage_seq"', 1, true);

-- ----------------------------
-- Sequence structure for templates_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."templates_id_seq";
CREATE SEQUENCE "public"."templates_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Table structure for accounts
-- ----------------------------
DROP TABLE IF EXISTS "public"."accounts";
CREATE TABLE "public"."accounts" (
"login" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"password" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"player_id" int8 DEFAULT nextval('account_id_seq'::regclass) NOT NULL,
"player_name" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"name_color" int4 DEFAULT 0 NOT NULL,
"clan_id" int4 DEFAULT 0 NOT NULL,
"rank" int4 DEFAULT 0 NOT NULL,
"gp" int4 DEFAULT 45000 NOT NULL,
"exp" int4 DEFAULT 0 NOT NULL,
"pc_cafe" int4 DEFAULT 0 NOT NULL,
"fights" int4 DEFAULT 0 NOT NULL,
"fights_win" int4 DEFAULT 0 NOT NULL,
"fights_lost" int4 DEFAULT 0 NOT NULL,
"kills_count" int4 DEFAULT 0 NOT NULL,
"deaths_count" int4 DEFAULT 0 NOT NULL,
"headshots_count" int4 DEFAULT 0 NOT NULL,
"escapes" int4 DEFAULT 0 NOT NULL,
"access_level" int4 DEFAULT 0 NOT NULL,
"lastip" varchar(32) COLLATE "default" DEFAULT 0 NOT NULL,
"email" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"last_rankup_date" int8 DEFAULT 1010000 NOT NULL,
"money" int4 DEFAULT 0 NOT NULL,
"online" bool DEFAULT false NOT NULL,
"weapon_primary" int4 DEFAULT 0 NOT NULL,
"weapon_secondary" int4 DEFAULT 601002003 NOT NULL,
"weapon_melee" int4 DEFAULT 702001001 NOT NULL,
"weapon_thrown_normal" int4 DEFAULT 803007001 NOT NULL,
"weapon_thrown_special" int4 DEFAULT 904007002 NOT NULL,
"char_red" int4 DEFAULT 1001001005 NOT NULL,
"char_blue" int4 DEFAULT 1001002006 NOT NULL,
"char_helmet" int4 DEFAULT 1102003001 NOT NULL,
"char_dino" int4 DEFAULT 1006003041 NOT NULL,
"char_beret" int4 DEFAULT 0 NOT NULL,
"brooch" int4 DEFAULT 10 NOT NULL,
"insignia" int4 DEFAULT 124 NOT NULL,
"medal" int4 DEFAULT 375 NOT NULL,
"blue_order" int4 DEFAULT 140 NOT NULL,
"mission_id1" int4 DEFAULT 0 NOT NULL,
"clanaccess" int4 DEFAULT 0 NOT NULL,
"clandate" int4 DEFAULT 0 NOT NULL,
"effects" int8 DEFAULT 0 NOT NULL,
"fights_draw" int4 DEFAULT 0 NOT NULL,
"mission_id2" int4 DEFAULT 0 NOT NULL,
"mission_id3" int4 DEFAULT 0 NOT NULL,
"totalkills_count" int4 DEFAULT 0 NOT NULL,
"totalfights_count" int4 DEFAULT 0 NOT NULL,
"status" int8 DEFAULT 4294967295::bigint NOT NULL,
"last_login" int8 DEFAULT 0 NOT NULL,
"clan_game_pt" int4 DEFAULT 0 NOT NULL,
"clan_wins_pt" int4 DEFAULT 0 NOT NULL,
"last_mac" macaddr DEFAULT '00:00:00:00:00:00'::macaddr NOT NULL,
"ban_obj_id" int8 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO "public"."accounts" VALUES ('pedroneto', '4edaf9820470dd5290d9ab45017f576c', '1', 'Stonex', '0', '0', '0', '99999999', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '127.0.0.1', '', '1010000', '0', 'f', '0', '601002003', '702001001', '803007001', '904007002', '1001001005', '1001002006', '1102003001', '1006003041', '0', '10', '124', '375', '140', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4294967295', '1809202013', '0', '0', '1c:1b:0d:1c:37:55', '0');

-- ----------------------------
-- Table structure for ban_history
-- ----------------------------
DROP TABLE IF EXISTS "public"."ban_history";
CREATE TABLE "public"."ban_history" (
"object_id" int8 DEFAULT nextval('ban_seq'::regclass) NOT NULL,
"provider_id" int8 DEFAULT 0 NOT NULL,
"type" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"value" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"reason" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"start_date" timestamp(6) DEFAULT '2000-01-01 00:00:00'::timestamp without time zone NOT NULL,
"end_date" timestamp(6) DEFAULT '2000-01-01 00:00:00'::timestamp without time zone NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of ban_history
-- ----------------------------

-- ----------------------------
-- Table structure for clan_data
-- ----------------------------
DROP TABLE IF EXISTS "public"."clan_data";
CREATE TABLE "public"."clan_data" (
"clan_id" int4 DEFAULT nextval('clan_seq'::regclass) NOT NULL,
"clan_rank" int4 DEFAULT 0 NOT NULL,
"clan_name" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"owner_id" int8 DEFAULT 0 NOT NULL,
"logo" int8 DEFAULT 0 NOT NULL,
"color" int4 DEFAULT 0 NOT NULL,
"clan_info" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"clan_news" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"create_date" int4 DEFAULT 0 NOT NULL,
"autoridade" int4 DEFAULT 0 NOT NULL,
"limite_rank" int4 DEFAULT 0 NOT NULL,
"limite_idade" int4 DEFAULT 0 NOT NULL,
"limite_idade2" int4 DEFAULT 0 NOT NULL,
"partidas" int4 DEFAULT 0 NOT NULL,
"vitorias" int4 DEFAULT 0 NOT NULL,
"derrotas" int4 DEFAULT 0 NOT NULL,
"pontos" float4 DEFAULT 1000 NOT NULL,
"max_players" int4 DEFAULT 50 NOT NULL,
"clan_exp" int4 DEFAULT 0 NOT NULL,
"best_exp" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"best_participation" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"best_wins" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"best_kills" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"best_headshot" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of clan_data
-- ----------------------------

-- ----------------------------
-- Table structure for clan_invites
-- ----------------------------
DROP TABLE IF EXISTS "public"."clan_invites";
CREATE TABLE "public"."clan_invites" (
"clan_id" int4 DEFAULT 0 NOT NULL,
"player_id" int8 DEFAULT 0 NOT NULL,
"dateinvite" int4 DEFAULT 0 NOT NULL,
"text" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of clan_invites
-- ----------------------------

-- ----------------------------
-- Table structure for events_login
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_login";
CREATE TABLE "public"."events_login" (
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL,
"reward_id" int4 DEFAULT 0 NOT NULL,
"reward_count" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_login
-- ----------------------------

-- ----------------------------
-- Table structure for events_mapbonus
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_mapbonus";
CREATE TABLE "public"."events_mapbonus" (
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL,
"map_id" int4 DEFAULT 0 NOT NULL,
"stage_type" int4 DEFAULT 0 NOT NULL,
"percent_xp" int4 DEFAULT 0 NOT NULL,
"percent_gp" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_mapbonus
-- ----------------------------

-- ----------------------------
-- Table structure for events_playtime
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_playtime";
CREATE TABLE "public"."events_playtime" (
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL,
"title" varchar(30) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"seconds_target" int8 DEFAULT 1000 NOT NULL,
"good_reward1" int4 DEFAULT 0 NOT NULL,
"good_reward2" int4 DEFAULT 0 NOT NULL,
"good_count1" int4 DEFAULT 0 NOT NULL,
"good_count2" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_playtime
-- ----------------------------

-- ----------------------------
-- Table structure for events_quest
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_quest";
CREATE TABLE "public"."events_quest" (
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_quest
-- ----------------------------

-- ----------------------------
-- Table structure for events_rankup
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_rankup";
CREATE TABLE "public"."events_rankup" (
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL,
"percent_xp" int4 DEFAULT 0 NOT NULL,
"percent_gp" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_rankup
-- ----------------------------

-- ----------------------------
-- Table structure for events_visit
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_visit";
CREATE TABLE "public"."events_visit" (
"event_id" int4 DEFAULT nextval('check_event_seq'::regclass) NOT NULL,
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL,
"title" varchar(59) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"checks" int4 DEFAULT 7 NOT NULL,
"goods1" varchar COLLATE "default" NOT NULL,
"counts1" varchar COLLATE "default" NOT NULL,
"goods2" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"counts2" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_visit
-- ----------------------------

-- ----------------------------
-- Table structure for events_xmas
-- ----------------------------
DROP TABLE IF EXISTS "public"."events_xmas";
CREATE TABLE "public"."events_xmas" (
"start_date" int8 DEFAULT 0 NOT NULL,
"end_date" int8 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of events_xmas
-- ----------------------------

-- ----------------------------
-- Table structure for friends
-- ----------------------------
DROP TABLE IF EXISTS "public"."friends";
CREATE TABLE "public"."friends" (
"owner_id" int8 DEFAULT 0 NOT NULL,
"friend_id" int8 DEFAULT 0 NOT NULL,
"state" int4 DEFAULT 0 NOT NULL,
"removed" bool DEFAULT false NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of friends
-- ----------------------------

-- ----------------------------
-- Table structure for info_basic_items
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_basic_items";
CREATE TABLE "public"."info_basic_items" (
"acquisition" int4 NOT NULL,
"item_id" int4 NOT NULL,
"item_name" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"item_count" int4 NOT NULL,
"item_equip" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_basic_items
-- ----------------------------
INSERT INTO "public"."info_basic_items" VALUES ('0', '601002003', 'K-5', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '702001001', 'M-7', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '803007001', 'K-400', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '904007002', 'Smoke', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '1001001005', 'Red Bulls', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '1001002006', 'Acid Pol', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '1006003041', 'Raptor', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '1006003042', 'Sting', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '1006003043', 'Acid', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('0', '1102003001', 'Capacete básico', '1', '3');
INSERT INTO "public"."info_basic_items" VALUES ('1', '100003004', 'K2', '100', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '200004003', 'K1', '100', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '200004134', 'OA93', '604800', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '300005003', 'SSG69', '100', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '702001014', 'GH5007', '604800', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '1001001015', 'Reinforced_Combo_D-Fox', '604800', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '1001002016', 'Reinforced_Combo_Leopard', '604800', '1');
INSERT INTO "public"."info_basic_items" VALUES ('1', '1300037007', '200% EXP Up', '1', '1');

-- ----------------------------
-- Table structure for info_channels
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_channels";
CREATE TABLE "public"."info_channels" (
"server_id" int4 DEFAULT 0 NOT NULL,
"channel_id" int4 DEFAULT 0 NOT NULL,
"type" int4 DEFAULT 0 NOT NULL,
"announce" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_channels
-- ----------------------------
INSERT INTO "public"."info_channels" VALUES ('1', '0', '3', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '1', '2', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '2', '1', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '3', '1', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '4', '1', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '5', '1', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '6', '1', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '7', '1', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '8', '4', 'Point Blank X Udp3');
INSERT INTO "public"."info_channels" VALUES ('1', '9', '5', 'Point Blank X Udp3');

-- ----------------------------
-- Table structure for info_cupons_flags
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_cupons_flags";
CREATE TABLE "public"."info_cupons_flags" (
"item_id" int4 NOT NULL,
"effect_flag" int8 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_cupons_flags
-- ----------------------------
INSERT INTO "public"."info_cupons_flags" VALUES ('1200007000', '1048576');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200008000', '262144');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200017000', '131072');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200026000', '32768');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200027000', '16384');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200028000', '8192');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200029000', '4096');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200030000', '2048');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200031000', '1024');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200032000', '512');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200033000', '65536');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200034000', '256');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200035000', '128');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200036000', '64');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200040000', '32');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200044000', '16');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200064000', '2097152');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200065000', '1');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200078000', '8');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200079000', '4');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200080000', '4194304');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200185000', '8388608');
INSERT INTO "public"."info_cupons_flags" VALUES ('1200242000', '16777216');

-- ----------------------------
-- Table structure for info_gameservers
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_gameservers";
CREATE TABLE "public"."info_gameservers" (
"id" int4 NOT NULL,
"state" int4 NOT NULL,
"type" int4 NOT NULL,
"ip" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"port" int4 NOT NULL,
"sync_port" int4 NOT NULL,
"max_players" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_gameservers
-- ----------------------------
INSERT INTO "public"."info_gameservers" VALUES ('0', '1', '1', '127.0.0.1', '39190', '1908', '100');
INSERT INTO "public"."info_gameservers" VALUES ('1', '1', '1', '127.0.0.1', '39191', '1909', '100');

-- ----------------------------
-- Table structure for info_login_configs
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_login_configs";
CREATE TABLE "public"."info_login_configs" (
"config_id" int4 DEFAULT 0 NOT NULL,
"onlyGM" bool DEFAULT false NOT NULL,
"missions" bool DEFAULT true NOT NULL,
"UserFileList" varchar(32) COLLATE "default" DEFAULT 0 NOT NULL,
"Version" varchar(8) COLLATE "default" DEFAULT 0 NOT NULL,
"GiftSystem" bool DEFAULT false NOT NULL,
"ExitURL" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_login_configs
-- ----------------------------
INSERT INTO "public"."info_login_configs" VALUES ('1', 'f', 't', 'bff24571c8ef83d22b41503e3f20cc49', '1.15.41', 't', '');

-- ----------------------------
-- Table structure for info_missions
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_missions";
CREATE TABLE "public"."info_missions" (
"mission_id" int4 DEFAULT 0 NOT NULL,
"price" int4 DEFAULT 0 NOT NULL,
"enable" bool DEFAULT false NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_missions
-- ----------------------------
INSERT INTO "public"."info_missions" VALUES ('1', '5000', 'f');
INSERT INTO "public"."info_missions" VALUES ('5', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('6', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('7', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('8', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('9', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('10', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('11', '5000', 't');
INSERT INTO "public"."info_missions" VALUES ('12', '5000', 't');

-- ----------------------------
-- Table structure for info_rank_awards
-- ----------------------------
DROP TABLE IF EXISTS "public"."info_rank_awards";
CREATE TABLE "public"."info_rank_awards" (
"rank_id" int4 NOT NULL,
"item_id" int4 NOT NULL,
"item_name" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"item_count" int4 NOT NULL,
"item_equip" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of info_rank_awards
-- ----------------------------
INSERT INTO "public"."info_rank_awards" VALUES ('0', '100003193', 'AUG LionFlame', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('0', '601002017', 'C. Phyton G D', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('0', '702001149', 'Fang Blade Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('0', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('1', '200004026', 'Kriss S.V G', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('1', '601014004', 'Dual D-Eagle G', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('1', '702001011', 'Amok Kukri D', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('1', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('2', '300005087', 'Cheytac M200 PBIC2014', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('2', '601002023', 'IMI Uzi 9mm', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('2', '702001066', 'DEATH_SCYTHE', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('2', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('3', '400006017', 'M1887 D', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('3', '601002022', 'Colt 45', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('3', '702001012', 'Mine Axe D', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('3', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('4', '100003121', 'AK47 PBIC2013', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('4', '702001147', 'Karambit', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('4', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('5', '200004075', 'P90 G', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('5', '702001024', 'CandyCane', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('5', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('6', '300005015', 'L11501 G', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('6', '702001021', 'Keris', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('6', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('7', '400006018', 'SPAS15_MSC', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('7', '702001041', 'Arabian Sword', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('7', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('8', '100003114', 'M401 Elite', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('8', '702001017', 'FANG_BLASE', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('8', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('9', '200004136', 'OA93 G', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('9', '702001017', 'FANG_BLASE', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('9', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('10', '300005017', 'L115A1_D', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('10', '803007062', 'K400 Alien', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('11', '400006011', '870MCS_W_D', '172800', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('11', '702001047', 'Keris XMAS', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('12', '601002052', 'C. Python TOY', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('12', '1001001034', 'Bella', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('13', '601002011', 'Glock18', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('13', '1001001011', 'Reinforced_D-Fox', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('14', '601002011', 'Glock18', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('14', '1001002014', 'Reinforced_Hide', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('15', '601002021', 'Glock18 D', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('15', '1001002051', 'Hide Kopassus', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('16', '601002021', 'Glock18 D', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('16', '1105003001', 'Santa HAT', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('17', '601002026', 'HK69', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('17', '1001002033', 'Chou', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('18', '601002083', 'C. Phyton BEAST', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('18', '1001001013', 'Reinforced_ViperRed', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('19', '601002083', 'C. Phyton BEAST', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('19', '1001002012', 'Reinforced_Leopard', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('20', '601002083', 'C. Phyton BEAST', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('20', '1001002053', 'Hide Soccer', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('21', '702001017', 'FANG_BLADE', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('21', '1104003015', 'Alien Masc', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('22', '702001017', 'FANG_BLADE', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('22', '1104003131', 'Mask Sheep', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('23', '702001017', 'FANG_BLADE', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('23', '1104003129', 'Mask PBIC2013', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('24', '702001004', 'Kukri', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('24', '1105003018', 'Chicken Hat', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('25', '702001049', 'Arabian Sword 2', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('25', '1105003010', 'Cangaceiro Hat', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('26', '702001009', 'M7 G', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('26', '1105003009', 'TOY Hat', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('27', '702001018', 'Ballistic Knife', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('27', '1105003001', 'Santa Hat', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('28', '100003063', 'AUG A3 Esport', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('28', '702001009', 'M7 G', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('29', '300005128', 'RangeMaster 338 CAMO', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('29', '702001012', 'Mine Axe D', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('30', '300005132', 'Tactilite T2 G', '259200', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('30', '702001066', 'Death Scythe', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('31', '702001057', 'Fang Blade Inferno', '2592001', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('31', '1105003010', 'Cangaceiro Hat', '2592001', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('32', '200004011', 'P90_DOTSIGHT', '86400', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('32', '702001011', 'Amok Kukri D', '2592001', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('33', '1300027003', 'Recarregamento Rapido', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('34', '1301047000', 'Alteração de Nick', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('35', '1300030003', 'Bullet Proof Vest', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('36', '1300026003', 'Troca Rápida', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('37', '1300032003', 'Hollow Point Plus', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('38', '1300017003', 'Receber Drop', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('39', '1301047000', 'Alteração de nick', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('40', '1300162007', 'O bom perdedor', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('41', '1300080003', '100% Redução de Respawn', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('42', '1300031007', 'Bala de Ferro', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('43', '1300034030', 'C4 Speed Kit', '0', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('44', '1301047000', 'Alteração de nick', '1', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('45', '1001001286', 'Viper General', '2592000', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('45', '1001002287', 'Hide General', '2592000', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('45', '1103003016', 'Beret General', '1', '3');
INSERT INTO "public"."info_rank_awards" VALUES ('46', '0', '0', '0', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('47', '0', '0', '0', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('48', '0', '0', '0', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('49', '0', '0', '0', '1');
INSERT INTO "public"."info_rank_awards" VALUES ('50', '0', '0', '0', '1');

-- ----------------------------
-- Table structure for nick_history
-- ----------------------------
DROP TABLE IF EXISTS "public"."nick_history";
CREATE TABLE "public"."nick_history" (
"player_id" int8 DEFAULT 0 NOT NULL,
"from_nick" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"to_nick" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"change_date" int8 DEFAULT 0 NOT NULL,
"motive" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of nick_history
-- ----------------------------
INSERT INTO "public"."nick_history" VALUES ('2', '', 'Teste', '1809160150', 'First nick');

-- ----------------------------
-- Table structure for player_bonus
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_bonus";
CREATE TABLE "public"."player_bonus" (
"player_id" int8 DEFAULT 0 NOT NULL,
"bonuses" int4 DEFAULT 0 NOT NULL,
"sightcolor" int4 DEFAULT 4 NOT NULL,
"freepass" int4 DEFAULT 0 NOT NULL,
"fakerank" int4 DEFAULT 55 NOT NULL,
"fakenick" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_bonus
-- ----------------------------
INSERT INTO "public"."player_bonus" VALUES ('2', '0', '4', '0', '55', '');

-- ----------------------------
-- Table structure for player_configs
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_configs";
CREATE TABLE "public"."player_configs" (
"owner_id" int8 DEFAULT 0 NOT NULL,
"config" int4 DEFAULT 55 NOT NULL,
"sangue" int4 DEFAULT 1 NOT NULL,
"mira" int4 DEFAULT 0 NOT NULL,
"mao" int4 DEFAULT 0 NOT NULL,
"audio1" int4 DEFAULT 100 NOT NULL,
"audio2" int4 DEFAULT 60 NOT NULL,
"audio_enable" int4 DEFAULT 7 NOT NULL,
"sensibilidade" int4 DEFAULT 50 NOT NULL,
"visao" int4 DEFAULT 70 NOT NULL,
"mouse_invertido" int4 DEFAULT 0 NOT NULL,
"msgconvite" int4 DEFAULT 0 NOT NULL,
"chatsussurro" int4 DEFAULT 0 NOT NULL,
"macro" int4 DEFAULT 31 NOT NULL,
"macro_1" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"macro_2" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"macro_3" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"macro_4" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"macro_5" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"keys" bytea DEFAULT '\x'::bytea NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_configs
-- ----------------------------

-- ----------------------------
-- Table structure for player_events
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_events";
CREATE TABLE "public"."player_events" (
"player_id" int8 DEFAULT 0 NOT NULL,
"last_visit_event_id" int4 DEFAULT 0 NOT NULL,
"last_visit_sequence1" int4 DEFAULT 0 NOT NULL,
"last_visit_sequence2" int4 DEFAULT 0 NOT NULL,
"next_visit_date" int4 DEFAULT 0 NOT NULL,
"last_xmas_reward_date" int8 DEFAULT 0 NOT NULL,
"last_playtime_date" int8 DEFAULT 0 NOT NULL,
"last_playtime_value" int4 DEFAULT 0 NOT NULL,
"last_playtime_finish" int4 DEFAULT 0 NOT NULL,
"last_login_date" int8 DEFAULT 0 NOT NULL,
"last_quest_date" int8 DEFAULT 0 NOT NULL,
"last_quest_finish" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_events
-- ----------------------------
INSERT INTO "public"."player_events" VALUES ('2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for player_items
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_items";
CREATE TABLE "public"."player_items" (
"object_id" int8 DEFAULT nextval('items_id_seq'::regclass) NOT NULL,
"owner_id" int8 DEFAULT 0 NOT NULL,
"item_id" int4 DEFAULT 0 NOT NULL,
"item_name" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"count" int8 DEFAULT 0 NOT NULL,
"category" int4 DEFAULT 0 NOT NULL,
"equip" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_items
-- ----------------------------
INSERT INTO "public"."player_items" VALUES ('2', '2', '100003004', 'K2', '100', '1', '1');
INSERT INTO "public"."player_items" VALUES ('3', '2', '200004003', 'K1', '100', '1', '1');
INSERT INTO "public"."player_items" VALUES ('4', '2', '200004134', 'OA93', '604800', '1', '1');
INSERT INTO "public"."player_items" VALUES ('5', '2', '300005003', 'SSG69', '100', '1', '1');
INSERT INTO "public"."player_items" VALUES ('6', '2', '702001014', 'GH5007', '604800', '1', '1');
INSERT INTO "public"."player_items" VALUES ('7', '2', '1001001015', 'Reinforced_Combo_D-Fox', '604800', '2', '1');
INSERT INTO "public"."player_items" VALUES ('8', '2', '1001002016', 'Reinforced_Combo_Leopard', '604800', '2', '1');
INSERT INTO "public"."player_items" VALUES ('9', '2', '1300037007', '200% EXP Up', '1', '3', '1');

-- ----------------------------
-- Table structure for player_messages
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_messages";
CREATE TABLE "public"."player_messages" (
"object_id" int4 DEFAULT nextval('message_id_seq'::regclass) NOT NULL,
"owner_id" int8 DEFAULT 0 NOT NULL,
"sender_id" int8 DEFAULT 0 NOT NULL,
"clan_id" int4 DEFAULT 0 NOT NULL,
"sender_name" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"text" varchar(255) COLLATE "default" DEFAULT ''::character varying NOT NULL,
"type" int4 DEFAULT 0 NOT NULL,
"state" int4 DEFAULT 1 NOT NULL,
"expire" int8 DEFAULT 0 NOT NULL,
"cb" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_messages
-- ----------------------------

-- ----------------------------
-- Table structure for player_missions
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_missions";
CREATE TABLE "public"."player_missions" (
"owner_id" int8 DEFAULT 0 NOT NULL,
"actual_mission" int4 DEFAULT 0 NOT NULL,
"card1" int4 DEFAULT 0 NOT NULL,
"card2" int4 DEFAULT 0 NOT NULL,
"card3" int4 DEFAULT 0 NOT NULL,
"card4" int4 DEFAULT 0 NOT NULL,
"mission1" bytea DEFAULT '\x'::bytea NOT NULL,
"mission2" bytea DEFAULT '\x'::bytea NOT NULL,
"mission3" bytea DEFAULT '\x'::bytea NOT NULL,
"mission4" bytea DEFAULT '\x'::bytea NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_missions
-- ----------------------------
INSERT INTO "public"."player_missions" VALUES ('2', '0', '0', '0', '0', '0', E'', E'', E'', E'');

-- ----------------------------
-- Table structure for player_titles
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_titles";
CREATE TABLE "public"."player_titles" (
"owner_id" int8 DEFAULT 0 NOT NULL,
"titleequiped1" int4 DEFAULT 0 NOT NULL,
"titleequiped2" int4 DEFAULT 0 NOT NULL,
"titleequiped3" int4 DEFAULT 0 NOT NULL,
"titleflags" int8 DEFAULT 0 NOT NULL,
"titleslots" int4 DEFAULT 1 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of player_titles
-- ----------------------------

-- ----------------------------
-- Table structure for shop
-- ----------------------------
DROP TABLE IF EXISTS "public"."shop";
CREATE TABLE "public"."shop" (
"good_id" int4 DEFAULT 0 NOT NULL,
"item_id" int4 DEFAULT 0 NOT NULL,
"item_name" varchar COLLATE "default" DEFAULT ''::character varying NOT NULL,
"price_gold" int4 DEFAULT 0 NOT NULL,
"price_cash" int4 DEFAULT 0 NOT NULL,
"count" int4 DEFAULT 0 NOT NULL,
"buy_type" int4 DEFAULT 0 NOT NULL,
"buy_type2" int4 DEFAULT 0 NOT NULL,
"buy_type3" int4 DEFAULT 0 NOT NULL,
"tag" int4 DEFAULT 0 NOT NULL,
"title" int4 DEFAULT 0 NOT NULL,
"visibility" int4 DEFAULT 0 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of shop
-- ----------------------------

-- ----------------------------
-- Table structure for tournament_rules
-- ----------------------------
DROP TABLE IF EXISTS "public"."tournament_rules";
CREATE TABLE "public"."tournament_rules" (
"tournament" varchar(255) COLLATE "default" NOT NULL,
"name_exception" varchar(255) COLLATE "default" NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of tournament_rules
-- ----------------------------
INSERT INTO "public"."tournament_rules" VALUES ('79', '[R]');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Ballistic');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Chinese Cleaver');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Espada Àrabe');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Field');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Field Shovel');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'hammer');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Kunai');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'Reinforced');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'WP Smoke');
INSERT INTO "public"."tournament_rules" VALUES ('79', 'WP Smoke D');
INSERT INTO "public"."tournament_rules" VALUES ('camp', '[R]');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Amok');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Anel de Anjo');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Ballistic');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Boina Che-Vermelha');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'C4 Speed Kit');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Cerberus');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Chapéu');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Cross Knife Beret');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Cupid');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'DarkSteel');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Demonic');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Dolphin ');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Elite');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Espada Àrabe');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'F.C');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Faca de Osso');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Fang');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'hat');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Kunai');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'M4 SR-16');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'mascara');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'máscara');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'mask');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Reinforced');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Reinforced Headgear');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Sakura');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Silence');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Smoke Plus');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'SPAS');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'SPAS-15');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Super Headgear');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'UTS-15');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'WP Smoke');
INSERT INTO "public"."tournament_rules" VALUES ('camp', 'Yellow Star Beret');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', '[R]');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Amok');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Anel de Anjo');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Ballistic');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Beret');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Boina');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Boina Che-Vermelha');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'C4 Speed Kit');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Cerberus');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Chapéu');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Cross Knife Beret');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Cupid');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'DarkSteel');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Demonic');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Dolphin ');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Elite');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Espada Àrabe');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'F.C');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Faca de Osso');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Fang');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'hat');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Headgear');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Kunai');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'M4 SR-16');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'mascara');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'máscara');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'mask');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Reinforced');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Reinforced Headgear');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Sakura');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Silence');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Smoke Plus');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'SPAS');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'SPAS-15');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Super Headgear');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'UTS-15');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'WP Smoke');
INSERT INTO "public"."tournament_rules" VALUES ('cnpb', 'Yellow Star Beret');

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table accounts
-- ----------------------------
ALTER TABLE "public"."accounts" ADD PRIMARY KEY ("player_id") WITH (fillfactor=23);

-- ----------------------------
-- Primary Key structure for table clan_data
-- ----------------------------
ALTER TABLE "public"."clan_data" ADD PRIMARY KEY ("clan_id");

-- ----------------------------
-- Primary Key structure for table player_configs
-- ----------------------------
ALTER TABLE "public"."player_configs" ADD PRIMARY KEY ("owner_id");
