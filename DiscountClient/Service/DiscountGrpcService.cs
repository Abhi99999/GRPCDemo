using DiscountServer.Protos;

namespace DiscountClient.Service
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountServiceClient)
        {
            _discountServiceClient = discountServiceClient;
        }

        public async Task<DiscountModel> GetDiscount(int discountId)
        {
            var request = new DiscountId
            {
                Id = discountId
            };

            // gRPC call
            //Note: For every RPC defined in your .proto, the C# gRPC client generates Async method
            var response = await _discountServiceClient.GetDiscountAsync(request);
            return response;
        }

        public async Task<DiscountDtoModel> CreateDiscount(DiscountModel discountModel)
        {
            //grpc call
            var response = await _discountServiceClient.CreateDiscountAsync(discountModel);
            return response;
        }
    }
}
