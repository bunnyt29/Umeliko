import { Banner } from "../banner/models/Banner";
import { Creator } from "../../../shared/models/Creator";
import { Lesson } from "../content/lesson/models/lesson";
import { Article } from "../content/article/models/Article";

export interface Material{
    id: string;
    contentType: string;
    stateType: any;
    banner: Banner;
    article: Article;
    lesson: Lesson;
    creator: Creator;
    showMore?: boolean;
}
