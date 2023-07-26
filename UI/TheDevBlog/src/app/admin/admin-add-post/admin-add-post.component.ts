import { Component, OnInit } from '@angular/core';
import { AddPostRequest } from 'src/app/models/add-post.models';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-admin-add-post',
  templateUrl: './admin-add-post.component.html',
  styleUrls: ['./admin-add-post.component.css']
})
export class AdminAddPostComponent implements OnInit {

  constructor(private postService: PostService) { }

  post: AddPostRequest = {
    Title: "",
    Content: "",
    Summary: "",
    UrlHandle: "",
    Author: "",
    Visible: true,
    PublishDate: "",
    UpdatedDate: "",
    FeaturedImageUrl: ""
  };

  ngOnInit(): void {
  }
  
  onSubmit(): void {
      this.postService.addPost(this.post).subscribe(response=>alert('Success!'));
    }
}
