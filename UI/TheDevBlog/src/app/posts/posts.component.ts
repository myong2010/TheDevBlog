import { PostService } from 'src/app/services/post.service';
import { Component, OnInit } from '@angular/core';
import { Post } from '../models/post.model';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  constructor(private postService: PostService) { }

  posts: Post[] = [];

  ngOnInit(): void {
    this.postService.getAllPosts().subscribe(response=>{
      this.posts = response;
    })
  }

}
