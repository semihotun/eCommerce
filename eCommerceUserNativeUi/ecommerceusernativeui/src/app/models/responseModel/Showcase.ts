export interface Showcase {
  id: string;
  showCaseOrder: number;
  showCaseTitle: string;
  showCaseType: string;
  showCaseText: string;
  showCaseProductList: ShowCaseProductList[];
}

export interface ShowCaseProductList {
  id: string;
  showCaseId: string;
  productId: string;
  showCaseText: string;
  productModel: ProductModel;
}

export interface ProductModel {
  id: string;
  productName: string;
  createdOnUtc: string;
  productPhotoList: ProductPhotoList[];
  productStock: ProductStock;
  productAttributeCombination: ProductAttributeCombination;
}

export interface ProductPhotoList {
  id: string;
  isDeleted: boolean;
  createdOnUtc: string;
  updatedOnUtc: string;
  productPhotoName: string;
  productId: string;
}

export interface ProductStock {
  id: string;
  isDeleted: boolean;
  createdOnUtc: string;
  updatedOnUtc: string;
  productPrice: number;
  productDiscount: number;
  productStockPiece: number;
  allowOutOfStockOrders: boolean;
  notifyAdminForQuantityBelow: number;
  createTime: string;
  productId: string;
  combinationId: string;
}

export interface ProductAttributeCombination {
  id: string;
  isDeleted: boolean;
  createdOnUtc: string;
  updatedOnUtc: string;
  productId: string;
  attributesXml: string;
  gtin: string;
  sku: string;
  manufacturerPartNumber: string;
}
