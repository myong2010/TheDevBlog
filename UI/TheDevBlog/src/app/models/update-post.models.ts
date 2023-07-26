export interface UpdatePostRequest {
 Title: string | undefined;
 Content: string | undefined;
 Summary: string | undefined;
 UrlHandle: string | undefined;
 Author: string | undefined;
 Visible: boolean | undefined;
 PublishDate: Date | undefined;
 UpdatedDate: Date | undefined;
 FeaturedImageUrl: string | undefined;
}