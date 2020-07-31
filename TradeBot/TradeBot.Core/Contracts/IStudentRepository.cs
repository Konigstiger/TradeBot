using System;
using System.Collections.Generic;

namespace TradeBot.Core
{
    public interface IStudentRepository
    {
        Student GetById(int id);
        void Save(Student student);
    }
}
