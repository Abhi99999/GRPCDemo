# GrpcDemo

In server side
step1: create everything except controller(no controller needed)
step2: create proto file based on blueprint of Irepo
step3: create service for proto. Inside class if type public override, it show methods ..(look code)


In client side
step1: look into code of service folder. you can addd it in controller by calling that class

Note: For every RPC defined in your .proto, the C# gRPC client generates Async method



Note: gRPC converts snake_case to PascalCase. Make to change property of server and client protobuf
