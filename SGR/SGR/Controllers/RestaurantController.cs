using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SGR.Application.Interfaces;
using SGR.Domain.Entities;
using SGR.Models;
using SGR.Models.Restaurant;

namespace SGR.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantAppService _restaurantAppService;

        public RestaurantController(IRestaurantAppService restaurantAppService)
        {
            _restaurantAppService = restaurantAppService;
        }

        //GET: List
        [HttpGet]
        public ActionResult Index()
        {
            var result = new ResultApi<RestaurantListViewModel>
            {
                Dados =
                    _restaurantAppService.Get()
                        .Select(x => new RestaurantListViewModel {Name = x.Name, RestaurantId = x.RestaurantId})
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Search
        [HttpGet]
        public ActionResult Search(string term)
        {
            var result = new ResultApi<RestaurantListViewModel>
            {
                Dados =
                    _restaurantAppService.Search(term)
                        .Select(x => new RestaurantListViewModel {Name = x.Name, RestaurantId = x.RestaurantId})
               
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(RestaurantAddViewModel model)
        {
            var result = new ResultApi<RestaurantListViewModel>();

            try
            {
                _restaurantAppService.Add(new Restaurant(model.Name));
            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Mensagem = e.Message;
             
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var result = new ResultApi<RestaurantEditViewModel>();

            try
            {
               var restaurant =  _restaurantAppService.GetById(id);

               result.Dados = new List<RestaurantEditViewModel> { new RestaurantEditViewModel {Name = restaurant.Name,RestaurantId = restaurant.RestaurantId} };
                
            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Mensagem = e.Message;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantEditViewModel model)
        {
            var result = new ResultApi<RestaurantListViewModel>();

            try
            {
                var restaurant = _restaurantAppService.GetById(model.RestaurantId);
                    restaurant.ChangeName(model.Name);
                    _restaurantAppService.Update(restaurant);
            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Mensagem = e.Message;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = new ResultApi<RestaurantListViewModel>();

            try
            {
                var restaurant = _restaurantAppService.GetById(id);
               
                _restaurantAppService.Remove(restaurant);
            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Mensagem = e.Message;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
