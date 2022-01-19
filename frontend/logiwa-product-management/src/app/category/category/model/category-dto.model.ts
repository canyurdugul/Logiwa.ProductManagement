import { BaseDto } from 'src/app/models/generic-model';

export interface CategoryDto extends BaseDto {
  name: string;
  minimumStockQuantity: number;
}
