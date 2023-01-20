﻿using AutoMapper;
using System.Globalization;
using TarotAPI.DTOs;
using TarotAPI.DTOs.Get;
using TarotAPI.DTOs.Post;
using TarotAPI.Models;

namespace TarotAPI.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Guild, GuildDto>()
                .ForMember(destiny =>
                destiny.GuildCreationDate,
                opt => opt.MapFrom(origin => origin.GuildCreationDate.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<GuildDto, Guild>()
                .ForMember(destiny =>
                destiny.GuildCreationDate,
                opt => opt.MapFrom(origin => DateTime.ParseExact(origin.GuildCreationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );

            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>()
                .ForMember(destiny =>
                destiny.Guild,
                opt => opt.Ignore()
                )
                .ForMember(destiny =>
                destiny.Teams,
                opt => opt.Ignore()
                );

            CreateMap<User, GetUserWithGuildDto>()
                .ForMember(destiny =>
                destiny.HireGuild,
                opt => opt.MapFrom(origin => origin.HireGuild.Value.ToString("dd/MM/yyyy"))
                )
                ;

            CreateMap<GetUserWithGuildDto, User>()
                .ForMember(destiny =>
                destiny.Guild,
                opt => opt.Ignore()
                )
                .ForMember(destiny =>
                destiny.Teams,
                opt => opt.Ignore()
                )
                .ForMember(destiny =>
                destiny.HireGuild,
                opt => opt.MapFrom(origin => DateTime.ParseExact(origin.HireGuild, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );

            CreateMap<Team, TeamDto>();


            CreateMap<TeamDto, Team>()
                .ForMember(destiny =>
                destiny.Characters,
                opt => opt.Ignore()
                );


            CreateMap<Team, CreateTeamDto>();

            CreateMap<CreateTeamDto, Team>()
                .ForMember(destiny =>
                destiny.User,
                opt => opt.Ignore()
                )
                .ForMember(destiny =>
                destiny.Characters,
                opt => opt.Ignore()
                );

            CreateMap<Team, GetTeamWithCharactersDto>();

            CreateMap<GetTeamWithCharactersDto, Team>()
                .ForMember(destiny =>
                destiny.Characters,
                opt => opt.Ignore()
                ).ReverseMap();

            CreateMap<Character, CharacterDto>();

            CreateMap<CharacterDto, Character>()
                .ForMember(destiny =>
                destiny.Teams,
                opt => opt.Ignore()
                );
        }
    }
}