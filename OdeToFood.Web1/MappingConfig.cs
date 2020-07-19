using OdeToFood.Data.Models;
using OdeToFood.Data.ViewModels;

namespace OdeToFood.Web1
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Restaurant, RestaurantViewModel>()
                .ForMember(dest => dest.selectedWeighterId,
                            option => option.MapFrom(src => src.WeighterId))
                .ForMember(dest => dest.Cuisine,
                            option => option.MapFrom(src => src.Cuisine));


                //config.CreateMap<RestaurantViewModel, Restaurant>()
                //.ConvertUsing(src => 
                //                {
                //                    return new Restaurant();
                //                });

            });
         }
    }
}