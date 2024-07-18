export class PaginationDTO<T> {
  constructor(
    public items?: T[],
    public hasNextPage?: boolean,
    public hasPrevPage?: boolean,
    public pageIndex?: number,
    public totalPages?: number,
    public pageSize?: number,
    public searchString?: string,
    public sortBy?: string,
    public sortType?: string
  ) {

  }
}
