﻿using System;
using System.Linq;
using AutoMapper;
using MemeHub.Models.BindingModels.Memes;
using MemeHub.Models.Models;
using MemeHub.Models.ViewModels.Memes;

namespace MemeHub.Services
{
    public class MemesService : Service, IMemesService
    {

        public void CreateMeme(MemeCreateBindingModel mcbm, string userName)
        {
            Meme meme = Mapper.Map<MemeCreateBindingModel, Meme>(mcbm);
            Poster poster = this.Context.Posters.FirstOrDefault(p => p.User.UserName == userName);
            meme.PostDate = DateTime.Now;
            poster.Memes.Add(meme);
            this.Context.SaveChanges();
        }

        public MemeDetailsViewModel GetMemeDetails(int? id)
        {
            throw new NotImplementedException();
        }

        public MemeEditViewModel GetEditMeme(int id)
        {
            Meme meme = this.Context.Memes.Find(id);
            MemeEditViewModel mevm = Mapper.Map<Meme, MemeEditViewModel>(meme);

            return mevm;
        }

        public void EditMeme(int id, MemeEditBindingModel bind)
        {
            Meme meme = this.Context.Memes.Find(id);
            meme.Caption = bind.Caption;

            this.Context.SaveChanges();
        }

        public MemeDeleteViewModel GetDeleteMeme(int? id)
        {
            Meme meme = this.Context.Memes.Find(id);
            MemeDeleteViewModel mdvm = Mapper.Map<Meme, MemeDeleteViewModel>(meme);

            return mdvm;
        }

        public void DeleteMeme(int id)
        {
            Meme meme = this.Context.Memes.Find(id);
            this.Context.Memes.Remove(meme);

            this.Context.SaveChanges();
        }
    }
}