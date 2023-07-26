import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from 'src/app/services/post.service';
import { Post } from 'src/app/models/post.model';
import { UpdatePostRequest } from 'src/app/models/update-post.models';

@Component({
  selector: 'app-admin-view-post',
  templateUrl: './admin-view-post.component.html',
  styleUrls: ['./admin-view-post.component.css']
})
export class AdminViewPostComponent implements OnInit {

  constructor(private route: ActivatedRoute, private postService: PostService) { }

  post: Post|undefined;
  ngOnInit(): void {
    this.route.paramMap.subscribe(params=>{const id = params.get('id');
    if(id){
     this.postService.getPostById(id).subscribe(response=>{this.post = response});}});
    }
  onSubmit(): void {
    const updatePostRequest: UpdatePostRequest = {
        Title: this.post?.Title,
        Content: this.post?.Content,
        Summary: this.post?.Summary,
        UrlHandle: this.post?.UrlHandle,
        Author: this.post?.Author,
        Visible: this.post?.Visible,
        PublishDate: this.post?.PublishDate,
        UpdatedDate: this.post?.UpdatedDate,
        FeaturedImageUrl: this.post?.FeaturedImageUrl,
      }
      this.postService.updatePost(this.post?.Id, updatePostRequest).subscribe(response=>alert('Success!'));
    }

    deletePost(): void {
      this.postService.deletePost(this.post?.Id).subscribe(response=>{alert("Deleted successfully!");})
    }
    
  }

