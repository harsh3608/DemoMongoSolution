﻿using System;


namespace Demo.Core.DTO
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T? Response { get; set; }
        public string? Message { get; set; }
    }
}
