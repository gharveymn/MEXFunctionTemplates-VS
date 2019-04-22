#include "mex.hpp"
#include "mexAdapter.hpp"

using namespace matlab::mex;
using namespace matlab::data;

class MexFunction : public Function {
private:
  matlab::data::ArrayFactory factory;
  const std::shared_ptr<matlab::engine::MATLABEngine> matlabPtr = getEngine();
public:
  void operator()(ArgumentList outputs, ArgumentList inputs) { 
    matlabPtr->feval(u"fprintf", 0, std::vector<Array>
            ({ factory.createScalar("hello, world\n")}));
  }
};
