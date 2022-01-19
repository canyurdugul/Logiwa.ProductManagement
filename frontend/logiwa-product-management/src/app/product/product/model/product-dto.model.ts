import { CategoryDto } from 'src/app/category/category/model/category-dto.model';
import { BaseDto } from 'src/app/models/generic-model';

export interface ProductDto extends BaseDto {
  title: string;
  description: string;
  stockQuantity: number;
  categoryId: number;
  category: CategoryDto;
}
