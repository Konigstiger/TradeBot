using System;
using System.Collections.Generic;

namespace TradeBot.Core
{
    public interface ICourseRepository
    {
        Course GetByCode(string code);
        List<Course> GetAll();
    }
}
