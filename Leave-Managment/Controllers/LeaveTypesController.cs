﻿using Leave_Managment.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Leave_Managment.Data;
using Leave_Managment.Mappings;
using Leave_Managment.Models;

namespace Leave_Managment.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
                
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList();
            var model = _mapper.Map < List<LeaveType>, List< LeaveTypeViewModel >> (leavetypes);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();

            }
            var leavetype= _repo.FindById(id);
            var model =_mapper.Map<LeaveTypeViewModel>(leavetype);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);

                }

                var leavetype = _mapper.Map<LeaveType>(model);
                leavetype.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(leavetype);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if(!_repo.isExists(id))
            {
               return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model=_mapper.Map<LeaveTypeViewModel>(leavetype);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);

                }

                var leavetype = _mapper.Map<LeaveType>(model);
                var isSuccess= _repo.Update(leavetype);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {

            var leavetype = _repo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(leavetype);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeViewModel model) //LeaveTypeViewmodel is just here to distinguish 
                                                                     //this delete from the delete from above
        {
            try
            {
                

                var leavetype = _repo.FindById(id);
                if(leavetype == null)
                {
                    return NotFound();
                }
                var isSuccess= _repo.Delete(leavetype);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
