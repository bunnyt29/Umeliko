export interface Creator{
    id: string;
    firstName: string;
    lastName: string;
    userName?: string;
    imageUrl?: string;
    bio?: string;
    email: string
    isFollowed: boolean
}
