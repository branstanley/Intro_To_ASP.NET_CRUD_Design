﻿
drop table if exists animals cascade; 
create table animals
(
	ID serial primary key,
	breed text null constraint valid_breed check (length(breed) > 0),
	weight real not null constraint valid_weight check (weight between 0 and 500),
	age real null constraint valid_age check(age between 0 and 100) 
);

comment on table animals is 'Animals in the shelter.';
comment on column animals.ID is 'The animal autogenerated ID.';
comment on column  animals.breed is 'The animal breed.';
comment on column animals.weight is 'The animal weight.';
grant select, insert, update, delete on table animals to "LU.ENG3675";

