using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SGR.Application.Interfaces;
using SGR.Domain.Entities;
using SGR.Models;
using SGR.Models.Dish;
using SGR.Models.Restaurant;

namespace SGR.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishAppService _dishAppService;
        public DishController(IDishAppService dishAppService)
        {
            _dishAppService = dishAppService;
        }

        //GET: List
        [HttpGet]
        public ActionResult Index()
        {
            var result = new ResultApi<DishListViewModel>
            {
                Dados =
                    _dishAppService.Get()
                        .Select(x => new DishListViewModel() { Name = x.Name, Restaurant = x.Restaurant.Name, DishId = x.DishId, Price = x.Price })
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(DishAddViewModel model)
        {
            var result = new ResultApi<DishAddViewModel>();

            try
            {
                _dishAppService.Add(new Dish(model.Name,model.Price,model.RestaurantId));
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
            var result = new ResultApi<DishEditViewModel>();

            try
            {
                var dish = _dishAppService.GetById(id);

                result.Dados = new List<DishEditViewModel> { new DishEditViewModel { Name = dish.Name, RestaurantId = dish.RestaurantId, DishId = dish.DishId, Price = dish.Price} };

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Mensagem = e.Message;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(DishEditViewModel model)
        {
            var result = new ResultApi<DishEditViewModel>();

            try
            {
                var dish = _dishAppService.GetById(model.DishId);

                dish
                    .ChangeName(model.Name)
                    .ChangePrice(model.Price)
                    .ChangeRestaurant(model.RestaurantId);

                _dishAppService.Update(dish);
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
            var result = new ResultApi<DishListViewModel>();

            try
            {
                var dish = _dishAppService.GetById(id);

                _dishAppService.Remove(dish);
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