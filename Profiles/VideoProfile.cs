using ApiRest.Data.Dtos;
using ApiRest.Models;
using AutoMapper;

namespace ApiRest.Profiles;

public class VideoProfile : Profile
{
	public VideoProfile()
	{
		CreateMap<CreateVideoDto, Video>();
		CreateMap<UpdateVideoDto, Video>();
		CreateMap<Video, UpdateVideoDto>();
	}
}
