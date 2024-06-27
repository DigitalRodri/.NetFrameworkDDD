﻿using System;

namespace Domain.DTOs
{
    public class AccountDto
    {
        public Guid UUID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }
    }
}