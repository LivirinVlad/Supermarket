@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  providers: [ProductService]
})
export class ProductListComponent {

  products: Product[] = [];

  constructor(private service: ProductService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.service.getAll()
      .subscribe(res => this.products = res as Product[]);
  }

  sell(id: string) {
    this.service.sell(id, 1)
      .subscribe(() => this.load());
  }

  add(id: string) {
    this.service.addStock(id, 5)
      .subscribe(() => this.load());
  }
}