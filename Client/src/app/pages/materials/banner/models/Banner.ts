export interface Banner{
    id: string;
    coverImageUrl: string;
    title: string;
    description: string;
    category: string;
    level: string;
    keywords: Array<{
      id: number;
      name: string;
    }>;
    materialId: string;
    showMore?: boolean;
}
