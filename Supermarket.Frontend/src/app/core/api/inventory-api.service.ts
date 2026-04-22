@Injectable({ providedIn: 'root' })
export class ProductApiService {

  private baseUrl = 'http://localhost:5001/api';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get(`${this.baseUrl}/products`);
  }
}