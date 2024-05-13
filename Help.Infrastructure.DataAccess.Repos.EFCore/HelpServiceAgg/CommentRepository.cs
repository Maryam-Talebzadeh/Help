using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
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

        public async Task Confirm(int id, CancellationToken cancellationToken)
        {
            var comment = Get(id);
            comment.Confirm();
        }

        public async Task Create(CreateCommentDTO command, CancellationToken cancellationToken)
        {
            var comment = new Comment(command.Message, command.Score, command.ParentId, command.HelpRequestId, command.CustomerId);
            _context.Comments.Add(comment);
        }

        public async Task Edit(EditCommentDTO command, CancellationToken cancellationToken)
        {
            var comment = Get(command.Id);
            comment.Edit(command.Message, command.Score);
        }

        public async Task<List<CommentDTO>> SearchUnConfirmed(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Comments.Where(c => !c.IsConfirmed).Select(c =>
            new CommentDTO()
            {
                HelpRequestId = c.HelpRequestId,
                Message = c.Message,
                Score = c.Score,
                Writer = new CustomerDTO()
                {
                    Id = c.Id,
                    Picture = new CustomerPictureDTO()
                    {
                        Title = c.Customer.Profile.Title,
                        Name = c.Customer.Profile.Name,
                        Alt = c.Customer.Profile.Alt,
                        CustomerId = c.Id
                    },
                    FullName = c.Customer.FullName
                }
            });

            if (searchModel.HelpRequestId > 0)
                query = query.Where(c => c.HelpRequestId == searchModel.HelpRequestId);

            if(!searchModel.Message.IsNullOrEmpty())
                query = query.Where(c => c.Message.Contains(searchModel.Message));

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }

        public async Task<List<CommentDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken)
        {
            return _context.Comments.Where(c => c.ParentId == parentId).Select(c =>
          new CommentDTO()
          {
              Id = c.Id,
              HelpRequestId = c.HelpRequestId,
              Message = c.Message,
              Score = c.Score,
              Writer = new CustomerDTO()
              {
                  Id = c.Id,
                  Picture = new CustomerPictureDTO()
                  {
                      Title = c.Customer.Profile.Title,
                      Name = c.Customer.Profile.Name,
                      Alt = c.Customer.Profile.Alt,
                      CustomerId = c.Id
                  },
                  FullName = c.Customer.FullName
              },
              Children = c.Children.Select(c =>
                  new CommentDTO()
                  {
                      HelpRequestId = c.HelpRequestId,
                      Message = c.Message,
                      Score = c.Score,
                      Writer = new CustomerDTO()
                      {
                          Id = c.Id,
                          Picture = new CustomerPictureDTO()
                          {
                              Title = c.Customer.Profile.Title,
                              Name = c.Customer.Profile.Name,
                              Alt = c.Customer.Profile.Alt,
                              CustomerId = c.Id
                          },
                          FullName = c.Customer.FullName
                      }
                  }).ToList()
          }).ToList();
        }

        public async Task<CommentDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Comments.Select(c =>
            new CommentDetailDTO()
            {
                HelpRequestId = c.HelpRequestId,
                Message = c.Message,
                Score = c.Score,
                CustomerId = c.CustomerId,
                Id = c.Id,
                ParentId = c.ParentId,
                Parent = new CommentDTO()
                {
                    HelpRequestId = c.HelpRequestId,
                    Message = c.Message,
                    Score = c.Score,
                    Writer = new CustomerDTO()
                    {
                        Id = c.Id,
                        Picture = new CustomerPictureDTO()
                        {
                            Title = c.Customer.Profile.Title,
                            Name = c.Customer.Profile.Name,
                            Alt = c.Customer.Profile.Alt,
                            CustomerId = c.Id
                        },
                        FullName = c.Customer.FullName
                    }
                },
                Children = c.Children.Select(c =>
                    new CommentDTO()
                    {
                        HelpRequestId = c.HelpRequestId,
                        Message = c.Message,
                        Score = c.Score,
                        Writer = new CustomerDTO()
                        {
                            Id = c.Id,
                            Picture = new CustomerPictureDTO()
                            {
                                Title = c.Customer.Profile.Title,
                                Name = c.Customer.Profile.Name,
                                Alt = c.Customer.Profile.Alt,
                                CustomerId = c.Id
                            },
                            FullName = c.Customer.FullName
                        }
                    }).ToList()
            }).FirstOrDefault(c => c.Id == id);
        }

        public async Task Reject(int id, CancellationToken cancellationToken)
        {
            var comment = Get(id);
            comment.Reject();
        }

        public async Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Comments.Where(c => c.IsConfirmed).Select(c =>
           new CommentDTO()
           {
               Id = c.Id,
               HelpRequestId = c.HelpRequestId,
               Message = c.Message,
               Score = c.Score,
               Writer = new CustomerDTO()
               {
                   Id = c.Id,
                   Picture = new CustomerPictureDTO()
                   {
                       Title = c.Customer.Profile.Title,
                       Name = c.Customer.Profile.Name,
                       Alt = c.Customer.Profile.Alt,
                       CustomerId = c.Id
                   },
                   FullName = c.Customer.FullName
               },
               Children = c.Children.Select(c =>
                   new CommentDTO()
                   {
                       HelpRequestId = c.HelpRequestId,
                       Message = c.Message,
                       Score = c.Score,
                       Writer = new CustomerDTO()
                       {
                           Id = c.Id,
                           Picture = new CustomerPictureDTO()
                           {
                               Title = c.Customer.Profile.Title,
                               Name = c.Customer.Profile.Name,
                               Alt = c.Customer.Profile.Alt,
                               CustomerId = c.Id
                           },
                           FullName = c.Customer.FullName
                       }
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