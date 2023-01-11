﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class SkillManager : ISkillService
    {
        ISkillDAL _skillDal;

        public SkillManager(ISkillDAL skilldal)
        {
            _skillDal = skilldal;
        }

        public Skill GetByID(int id)
        {
            return _skillDal.Get(x => x.SkillID == id);

        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }

        public void SkillAdd(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public void SkillUpdate(Skill skill)
        {
            _skillDal.Update(skill);
        }

        Admin ISkillService.GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
