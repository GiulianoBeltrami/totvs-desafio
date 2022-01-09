﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using totvs_desafio.Context;
using totvs_desafio.Database;
using totvs_desafio.Models;

namespace totvs_desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private UserContext _context;
        private ControllerErrors _errors;


        public RegistrationController(UserContext context, ControllerErrors errors)
        {
            _context = context;
            _errors = errors;
        }


        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<User>> Get()
        {
            var userList = DapperQuery.getAllUsers();
            return Ok(userList);
        }


        [HttpPost]
        [Produces("application/json")]
        public ActionResult Post(User user)
        {
            Validations validations = new Validations(user);

            if (!validations.isRegistrationFieldsFilled())
            {
                return _errors.incorrectFieldsError();
            }

            if (validations.isExistingEmail())
            {
                return _errors.existingEmailError();
            }

            if (validations.isLastAccessedFilled())
            {
                user.LastAccessed = user.created;
            }

            Password password = new Password();
            user.password = password.encrypt(user.password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


    }
}
