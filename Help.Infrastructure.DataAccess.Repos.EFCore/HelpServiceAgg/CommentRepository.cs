﻿using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class CommentRepository : BaseRepository_EFCore<Comment>, ICommentRepository
    {
        private readonly HelpContext _context;

        public CommentRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public void Confirm(long id)
        {
            var comment = Get(id);
            comment.Confirm();
        }

        public void Create(CreateCommentDTO command)
        {
            var comment = new Comment(command.Message, command.Score, command.ParentId, command.HelpRequestId, command.CustomerRoleId);
            _context.Comments.Add(comment);
        }

        public void Edit(EditCommentDTO command)
        {
            var comment = Get(command.Id);
            comment.Edit(command.Message, command.Score);
        }

        public List<CommentDTO> GetAllUnConfirmed(SearchCommentDTO searchModel)
        {
            var query = _context.Comments.Where(c => !c.IsConfirmed).Select(c =>
            new CommentDTO()
            {
                HelpRequestId = c.HelpRequestId,
                Message = c.Message,
                Score = c.Score,
                CustomerRoleId = c.CustomerRoleId,
                Parent = new CommentDTO()
                    {
                    HelpRequestId = c.HelpRequestId,
                    Message = c.Message,
                    Score = c.Score,
                    CustomerRoleId = c.CustomerRoleId
                }
            });

            if (searchModel.HelpRequestId > 0)
                query = query.Where(c => c.HelpRequestId == searchModel.HelpRequestId);

            if(!searchModel.Message.IsNullOrEmpty())
                query = query.Where(c => c.Message.Contains(searchModel.Message));

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }

        public CommentDetailDTO GetDetails(long id)
        {
            return _context.Comments.Select(c =>
            new CommentDetailDTO()
            {
                HelpRequestId = c.HelpRequestId,
                Message = c.Message,
                Score = c.Score,
                CustomerRoleId = c.CustomerRoleId,
                Id = c.Id,
                ParentId = c.ParentId,
                Parent = new CommentDTO()
                {
                    HelpRequestId = c.HelpRequestId,
                    Message = c.Message,
                    Score = c.Score,
                    CustomerRoleId = c.CustomerRoleId
                },
                Children = c.Children.Select(c =>
                    new CommentDTO()
                    {
                        HelpRequestId = c.HelpRequestId,
                        Message = c.Message,
                        Score = c.Score,
                        CustomerRoleId = c.CustomerRoleId
                    }).ToList()
            }).SingleOrDefault(c => c.Id == id);
        }

        public List<CommentDTO> Search(SearchCommentDTO searchModel)
        {
            var query = _context.Comments.Where(c => c.IsConfirmed).Select(c =>
           new CommentDTO()
           {
               Id = c.Id,
               HelpRequestId = c.HelpRequestId,
               Message = c.Message,
               Score = c.Score,
               CustomerRoleId = c.CustomerRoleId,
               Parent = new CommentDTO()
               {
                   HelpRequestId = c.HelpRequestId,
                   Message = c.Message,
                   Score = c.Score,
                   CustomerRoleId = c.CustomerRoleId
               },
               Children = c.Children.Select(c =>
                   new CommentDTO()
                   {
                       HelpRequestId = c.HelpRequestId,
                       Message = c.Message,
                       Score = c.Score,
                       CustomerRoleId = c.CustomerRoleId
                   }).ToList()
           });

            if (searchModel.HelpRequestId > 0)
                query = query.Where(c => c.HelpRequestId == searchModel.HelpRequestId);

            if (!searchModel.Message.IsNullOrEmpty())
                query = query.Where(c => c.Message.Contains(searchModel.Message));

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}