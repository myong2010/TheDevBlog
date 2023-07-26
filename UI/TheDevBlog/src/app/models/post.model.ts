export interface Post {
  Id: string;
  Title: string;
  Content: string;
  Summary: string;
  UrlHandle: string;
  Author: string;
  Visible: boolean;
  PublishDate: Date;
  UpdatedDate: Date;
  FeaturedImageUrl: string;
}