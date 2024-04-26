import { Creator } from "./Creator";

export interface Comment{
    id: string;
    content: string;
    materialId: string;
    creatorId: string;
    creator:Creator
}