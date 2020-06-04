using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.Post;
using LambdaForums.Models.Reply;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LambdaForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postservice;
        public PostController(IPost postService)
        {
            _postservice = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postservice.GetById(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel 
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.Users.Id,
                AuthorName = post.Users.UserName,
                AuthorImageUrle = post.Users.ProfileImageUrl,
                AuthorRating = post.Users.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies

            };

            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel 
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}